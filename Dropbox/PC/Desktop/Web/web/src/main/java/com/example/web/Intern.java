package com.example.web;


import jakarta.persistence.*;

@Entity
@Table
public class Intern {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY, generator = "intern_sequence")
    @SequenceGenerator(name = "intern_sequence", sequenceName = "intern_sequence", allocationSize = 1)

    private Object id;
    private String name;
    @Transient
    private int age;
    private String university;
    private String email;

    // Constructor
    public Intern(String name, int age, String university, String email) {
        this.name = name;
        this.age = age;
        this.university = university;
        this.email = email;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public String getUniversity() {
        return university;
    }

    public void setUniversity(String university) {
        this.university = university;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public Object getId() {
        return id;
    }

    public void setId(Object id) {
        this.id = id;
    }
}
