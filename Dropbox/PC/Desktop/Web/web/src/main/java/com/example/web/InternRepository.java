package com.example.web;

import java.util.Optional;

import org.springframework.data.jdbc.repository.query.Query;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;


@Repository
public interface InternRepository extends JpaRepository<Intern, Long> {
    // You can add custom query methods here if needed
    @Query("SELECT s FROM mydatabase s WHEWE  s.name = ?1")
    Optional<Intern> findInternByName(String name);
    @Query("SELECT s FROM mydatabase s WHEWE  s.id = ?1")
    Optional<Intern> findById(int id);
    Optional<Intern> existsById(int id);
}
