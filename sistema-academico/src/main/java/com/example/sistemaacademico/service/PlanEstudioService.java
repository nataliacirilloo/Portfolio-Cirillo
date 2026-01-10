package com.example.sistemaacademico.service;

import com.example.sistemaacademico.entity.Carrera;
import com.example.sistemaacademico.entity.Materia;
import com.example.sistemaacademico.repository.CarreraRepository;
import com.example.sistemaacademico.repository.MateriaRepository;
import org.apache.poi.ss.usermodel.*;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;
import java.io.InputStream;
import java.util.Iterator;
import java.util.List;

@Service
public class PlanEstudioService {

    @Autowired
    private MateriaRepository materiaRepository;

    @Autowired
    private CarreraRepository carreraRepository;

    @Autowired
    private com.example.sistemaacademico.repository.UsuarioRepository UsuarioRepository;

    @org.springframework.transaction.annotation.Transactional
    public void importarPlan(MultipartFile file) throws IOException {
        try (InputStream inputStream = file.getInputStream();
                Workbook workbook = WorkbookFactory.create(inputStream)) {

            Sheet sheet = workbook.getSheetAt(0);
            Iterator<Row> rows = sheet.iterator();
            DataFormatter formatter = new DataFormatter();

            if (rows.hasNext())
                rows.next();

            // Get Current User
            String email = org.springframework.security.core.context.SecurityContextHolder.getContext()
                    .getAuthentication().getName();
            com.example.sistemaacademico.entity.Usuario usuario = UsuarioRepository.findByEmail(email)
                    .orElseThrow(() -> new RuntimeException("Usuario no encontrado"));

            // Ensure Carrera for User
            Carrera carrera = carreraRepository.findByUsuarioId(usuario.getId()).stream().findFirst().orElseGet(() -> {
                Carrera c = new Carrera();
                c.setNombre("Ingeniería Informática"); 
                c.setDuracionAnios(5);
                c.setUsuario(usuario);
                return carreraRepository.save(c);
            });

            // Temporary storage for Pass 2
            List<Row> rowList = new java.util.ArrayList<>();
            while (rows.hasNext()) {
                rowList.add(rows.next());
            }

            java.util.Map<String, Materia> codeToMateriaMap = new java.util.HashMap<>();

            // PASS 1: Create Entities
            int rowIdx = 1;
            for (Row currentRow : rowList) {
                rowIdx++;
                try {
                    String anioStr = formatter.formatCellValue(currentRow.getCell(0));
                    String cuatStr = formatter.formatCellValue(currentRow.getCell(1));
                    String codeStr = formatter.formatCellValue(currentRow.getCell(2));
                    String nomStr = formatter.formatCellValue(currentRow.getCell(3));

                    if (anioStr.trim().isEmpty() || nomStr.trim().isEmpty())
                        continue;

                    Materia materia = new Materia();
                    materia.setAnio((int) tryParseDouble(anioStr));
                    materia.setCuatrimestre((int) tryParseDouble(cuatStr));
                    materia.setCodigo(codeStr.trim());
                    materia.setNombre(nomStr.trim());
                    materia.setCreditos(6);
                    materia.setCarrera(carrera);
                    materia.setEstado(com.example.sistemaacademico.entity.EstadoMateria.PENDIENTE);

                    materia = materiaRepository.save(materia);
                    codeToMateriaMap.put(materia.getCodigo(), materia);

                } catch (Exception e) {
                    throw new RuntimeException("Error en Fila " + rowIdx + " (Pase 1): " + e.getMessage());
                }
            }

            // PASS 2: Link Correlatives
            rowIdx = 1;
            for (Row currentRow : rowList) {
                rowIdx++;
                try {
                    String codeStr = formatter.formatCellValue(currentRow.getCell(2)).trim();
                    String corrStr = formatter.formatCellValue(currentRow.getCell(4)); // Col 4: Correlativas

                    if (corrStr == null || corrStr.trim().isEmpty() || corrStr.trim().equals("-")) {
                        continue;
                    }

                    Materia currentMateria = codeToMateriaMap.get(codeStr);
                    if (currentMateria == null)
                        continue;

                    java.util.List<Materia> correlativas = new java.util.ArrayList<>();
                    // Split by comma, maybe space? "01, 02"
                    String[] codes = corrStr.split(",");
                    for (String c : codes) {
                        String cleanCode = c.trim();
                        if (!cleanCode.isEmpty()) {
                            Materia dep = codeToMateriaMap.get(cleanCode);
                            if (dep != null) {
                                correlativas.add(dep);
                            } else {
                                System.err.println("Warning: Correlativa " + cleanCode + " not found for " + codeStr);
                            }
                        }
                    }

                    currentMateria.setCorrelativas(correlativas);
                    materiaRepository.save(currentMateria);

                } catch (Exception e) {
                    throw new RuntimeException("Error en Fila " + rowIdx + " (Pase 2): " + e.getMessage());
                }
            }
        }
    }

    private double tryParseDouble(String val) {
        try {
            if (val == null || val.trim().isEmpty())
                return 0;
            return Double.parseDouble(val.trim().replace(",", "."));
        } catch (NumberFormatException e) {
            return 0;
        }
    }
}
