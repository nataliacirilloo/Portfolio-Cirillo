package com.example.sistemaacademico.repository;

import com.example.sistemaacademico.entity.Carrera;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface CarreraRepository extends JpaRepository<Carrera, Long> {
    java.util.List<Carrera> findByUsuarioId(Long usuarioId);
}
