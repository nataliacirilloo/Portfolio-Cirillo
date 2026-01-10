package com.example.sistemaacademico.service;

import com.example.sistemaacademico.entity.EstadoMateria;
import com.example.sistemaacademico.entity.Materia;
import com.example.sistemaacademico.repository.MateriaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

@Service
@Transactional
public class AcademicTrackingService {

    @Autowired
    private MateriaRepository materiaRepository;

    @Autowired
    private com.example.sistemaacademico.repository.UsuarioRepository usuarioRepository;

    private com.example.sistemaacademico.entity.Usuario getCurrentUser() {
        String email = org.springframework.security.core.context.SecurityContextHolder.getContext().getAuthentication()
                .getName();
        return usuarioRepository.findByEmail(email)
                .orElseThrow(() -> new RuntimeException("Usuario no encontrado"));
    }

    public List<Materia> listarTodasLasMaterias() {
        return materiaRepository.findByCarrera_Usuario_Id(getCurrentUser().getId());
    }

    public Materia actualizarEstado(Long materiaId, EstadoMateria nuevoEstado) {
        Materia materia = materiaRepository.findById(materiaId)
                .orElseThrow(() -> new RuntimeException("Materia no encontrada"));

        // Validaciones Reglas de Negocio
        if (nuevoEstado == EstadoMateria.CURSANDO) {
            if (!esCursable(materia)) {
                throw new RuntimeException("No se puede cursar: Materia bloqueada o correlativas pendientes.");
            }
        }

        if (nuevoEstado == EstadoMateria.APROBADA) {
            // Nota validation would be here
        }

        materia.setEstado(nuevoEstado);
        materia = materiaRepository.save(materia);

        // Disparar actualizaciones en cascada
        actualizarEstadosAutomaticamente();

        return materia;
    }

    public void actualizarEstadosAutomaticamente() {
        List<Materia> todas = listarTodasLasMaterias();
        boolean changed = false;

        for (Materia m : todas) {
            // Solo re-evaluamos materias no aprobadas ni cursando
            if (m.getEstado() == EstadoMateria.APROBADA || m.getEstado() == EstadoMateria.CURSANDO) {
                continue;
            }

            // Verificar si todas las correlativas están aprobadas
            boolean correlativasAprobadas = true;
            if (m.getCorrelativas() != null) {
                for (Materia corr : m.getCorrelativas()) {
                    if (corr.getEstado() != EstadoMateria.APROBADA) {
                        correlativasAprobadas = false;
                        break;
                    }
                }
            }

            EstadoMateria estadoCalculado = correlativasAprobadas ? EstadoMateria.PENDIENTE : EstadoMateria.BLOQUEADA;

            if (m.getEstado() != estadoCalculado) {
                m.setEstado(estadoCalculado);
                changed = true;
            }
        }

        if (changed) {
            materiaRepository.saveAll(todas);
        }
    }

    public boolean esCursable(Materia materia) {
        if (materia.getEstado() == EstadoMateria.APROBADA || materia.getEstado() == EstadoMateria.CURSANDO) {
            return false;
        }
        if (materia.getCorrelativas() == null || materia.getCorrelativas().isEmpty()) {
            return true;
        }
        return materia.getCorrelativas().stream()
                .allMatch(c -> c.getEstado() == EstadoMateria.APROBADA);
    }

    public Map<String, Object> obtenerDashboard() {
        List<Materia> todas = listarTodasLasMaterias(); // Uses filtered list

        long aprobadas = todas.stream().filter(m -> m.getEstado() == EstadoMateria.APROBADA).count();
        long cursando = todas.stream().filter(m -> m.getEstado() == EstadoMateria.CURSANDO).count();
        long pendientes = todas.stream().filter(m -> m.getEstado() == EstadoMateria.PENDIENTE).count();
        long bloqueadas = todas.stream().filter(m -> m.getEstado() == EstadoMateria.BLOQUEADA).count();

        double porcentaje = todas.isEmpty() ? 0 : ((double) aprobadas / todas.size()) * 100;

        Map<String, Object> dashboard = new HashMap<>();
        dashboard.put("totalMaterias", todas.size());
        dashboard.put("materiasAprobadas", aprobadas);
        dashboard.put("materiasCursadas", cursando);
        dashboard.put("materiasPendientes", pendientes);
        dashboard.put("materiasBloqueadas", bloqueadas);
        dashboard.put("porcentajeAvance", Math.round(porcentaje * 100.0) / 100.0);
        dashboard.put("carrera", "Ingeniería Informática"); // TODO: Load actual carrera name
        dashboard.put("alumno", getCurrentUser().getNombre() + " " + getCurrentUser().getApellido());

        return dashboard;
    }

    public List<Map<String, Object>> obtenerMateriasConEstado() {
        List<Materia> materias = listarTodasLasMaterias();
        return materias.stream().map(m -> {
            Map<String, Object> map = new HashMap<>();
            map.put("id", m.getId());
            map.put("nombre", m.getNombre());
            map.put("anio", m.getAnio());
            map.put("cuatrimestre", m.getCuatrimestre());
            map.put("creditos", m.getCreditos());
            map.put("estado", m.getEstado());
            map.put("nota", m.getNota());
            boolean cursable = esCursable(m);
            map.put("esCursable", cursable);

            if (!cursable && m.getEstado() == EstadoMateria.BLOQUEADA) {
                List<String> faltantes = m.getCorrelativas().stream()
                        .filter(c -> c.getEstado() != EstadoMateria.APROBADA)
                        .map(Materia::getNombre)
                        .collect(Collectors.toList());
                map.put("correlativasFaltantes", faltantes);
            }

            return map;
        }).collect(Collectors.toList());
    }
}
