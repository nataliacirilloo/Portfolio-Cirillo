package com.example.sistemaacademico.controller;

import com.example.sistemaacademico.service.PlanEstudioService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

@RestController
@RequestMapping("/api/plan")
@CrossOrigin(origins = "*") // For development simplicity
public class PlanEstudioController {

    @Autowired
    private PlanEstudioService planEstudioService;

    @PostMapping("/upload")
    public ResponseEntity<String> uploadPlan(@RequestParam("file") MultipartFile file) {
        try {
            planEstudioService.importarPlan(file);
            return ResponseEntity.ok("Plan de estudios importado exitosamente.");
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.badRequest().body("Error al importar el plan: " + e.getMessage());
        }
    }
}
