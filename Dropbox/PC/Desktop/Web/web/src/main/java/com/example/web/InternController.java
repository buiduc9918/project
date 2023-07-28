package com.example.web;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
@RestController
@RequestMapping
@Controller
public class InternController {
    private final InternManagementSystem internManagementSystem;
    public InternController(InternManagementSystem internManagementSystem) {
        this.internManagementSystem = internManagementSystem;
    }
    @GetMapping("/interns")
    public String internsPage(Model model) {
        model.addAttribute("interns", internManagementSystem.viewAllInterns());
        return "interns";
    }
    @PutMapping("/interns/{id}")
    public ResponseEntity<Intern> updateIntern(@PathVariable Long id, @RequestBody Intern updatedIntern) {
        Intern intern = internManagementSystem.getInternById(id);

        if (intern == null) {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }
        intern.setName(updatedIntern.getName());
        intern.setAge(updatedIntern.getAge());
        intern.setUniversity(updatedIntern.getUniversity());
        intern.setEmail(updatedIntern.getEmail());
        return new ResponseEntity<>(intern, HttpStatus.OK);
    }
    @DeleteMapping("/interns/{id}")
    public ResponseEntity<Void> deleteIntern(@PathVariable Long id) {
        Intern intern = internManagementSystem.getInternById(id);
        if (intern == null) {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }
        return new ResponseEntity<>(HttpStatus.NO_CONTENT);
    }
}