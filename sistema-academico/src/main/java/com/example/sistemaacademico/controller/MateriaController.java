package com.example.sistemaacademico.controller;

import com.example.sistemaacademico.entity.EstadoMateria;
import com.example.sistemaacademico.service.AcademicTrackingService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Map;

@RestController
@RequestMapping("/api/materias")
@CrossOrigin(origins = "*")
public class MateriaController {

    @Autowired
    private AcademicTrackingService academicTrackingService;

    @GetMapping
    public ResponseEntity<List<Map<String, Object>>> listarMaterias() {
        return ResponseEntity.ok(academicTrackingService.obtenerMateriasConEstado());
    }

    @GetMapping("/dashboard")
    public ResponseEntity<Map<String, Object>> obtenerDashboard() {
        return ResponseEntity.ok(academicTrackingService.obtenerDashboard());
    }

    @PutMapping("/{id}/estado")
    public ResponseEntity<?> actualizarEstado(@PathVariable Long id, @RequestBody Map<String, String> payload) {
        try {
            String nuevoEstadoStr = payload.get("estado");
            EstadoMateria nuevoEstado = EstadoMateria.valueOf(nuevoEstadoStr);
            Object actualizado = academicTrackingService.actualizarEstado(id, nuevoEstado);
            return ResponseEntity.ok(actualizado);
        } catch (IllegalArgumentException e) {
            return ResponseEntity.badRequest().body("Estado inválido.");
        } catch (RuntimeException e) {
            e.printStackTrace();
            return ResponseEntity.badRequest().body(e.getMessage());
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.internalServerError().body("Error interno: " + e.getMessage());
        }
    }
}
