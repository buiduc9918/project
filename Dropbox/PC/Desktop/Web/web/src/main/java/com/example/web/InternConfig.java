package com.example.web;


import java.util.List;

import org.aspectj.apache.bcel.classfile.JavaClass;
import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Configuration;

@Configuration
public class InternConfig {
    CommandLineRunner commandLineRunner(InternRepository internRepository){
        return args -> {
           Intern Duc = new Intern( "duc",22,"ptit","buiduc9918@gmail.com");
           Intern Chien = new Intern("chien",22,"ptit","chien9918@gmail.com");
                org.aspectj.apache.bcel.Repository.addClass(
               (JavaClass) List.of(Duc,Chien)
           );
        };
    }
}
