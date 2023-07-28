package com.example.web;
import java.util.ArrayList;
import java.util.List;

public class InternManagementSystem {
    private List<Intern> interns;

    public InternManagementSystem() {
        interns = new ArrayList<>();
    }

    // Add a new intern
    public void addIntern(Intern intern) {
        interns.add(intern);
    }

    // View all interns
    public List<Intern> viewAllInterns() {
        for (Intern intern : interns) {
            System.out.println(intern.getName() + " | " + intern.getAge() + " | " + intern.getUniversity() + " | " + intern.getEmail());
        }
        return interns;

    }

    // Update intern details
    public void updateIntern(Intern intern, String newName, int newAge, String newUniversity, String newEmail) {
        intern.setName(newName);
        intern.setAge(newAge);
        intern.setUniversity(newUniversity);
        intern.setEmail(newEmail);
    }

    // Remove an intern
    public void removeIntern(Intern intern) {
        interns.remove(intern);
    }
    public Intern getInternById(Long id) {
        for (Intern intern : interns) {
            if (intern.getId().equals(id)) {
                return intern;
            }
        }
        return null; // Return null if no intern with the specified ID is found
    }
}
