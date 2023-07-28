package com.example.web;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
@RequestMapping
@Controller
@RestController
public class HomeController {
    @GetMapping("/")
    public String homePage() {
        return "home"; // Return the name of the home.html template
    }
}