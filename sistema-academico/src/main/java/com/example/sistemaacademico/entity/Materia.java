package com.example.sistemaacademico.entity;

import jakarta.persistence.*;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Data
@NoArgsConstructor
@com.fasterxml.jackson.annotation.JsonIgnoreProperties({ "hibernateLazyInitializer", "handler" })
public class Materia {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false)
    private String nombre;

    @Column(unique = true) // Remove nullable=false temporarily to allow easy migration/import if code is missing in old data, but better to force it if we drop db. Let's stick to user request.
    private String codigo;

    @Column(nullable = false)
    private Integer anio;

    @Column(nullable = false)
    private Integer cuatrimestre;

    @Column(nullable = false)
    private Integer creditos;

    @Enumerated(EnumType.STRING)
    private EstadoMateria estado = EstadoMateria.PENDIENTE; // Default state

    private Integer nota;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "carrera_id")
    @com.fasterxml.jackson.annotation.JsonIgnore
    private Carrera carrera;

    @ManyToMany(fetch = FetchType.LAZY)
    @JoinTable(
        name = "materia_correlativas",
        joinColumns = @JoinColumn(name = "materia_id"),
        inverseJoinColumns = @JoinColumn(name = "correlativa_id")
    )
    @com.fasterxml.jackson.annotation.JsonIgnoreProperties("correlativas")
    private java.util.List<Materia> correlativas;
}