package com.example.web;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class InternService {
    private final InternRepository internRepository;

    @Autowired
    public InternService(InternRepository internRepository) {
        this.internRepository = internRepository;
    }

    @Autowired
    public List<Intern> getAllInterns() {
        return internRepository.findAll();
    }

    @Autowired
    public Intern getInternById(Long id) {
        return internRepository.findById(id).orElse(null);
    }

    @Autowired
    public Intern saveIntern(Intern intern) {
        return internRepository.save(intern);
    }

    @Autowired
    public void deleteIntern(Long id) {
        internRepository.deleteById(id);
    }
    
    public void addNewIntern(Intern intern){
       Optional<Intern> internByName = internRepository.findInternByName(intern.getName());
            if(internByName.isPresent()){
                throw new IllegalStateException("name taken");
            }
        internRepository.save(intern);
    }

    public void deleteIntern(int id){
       Optional<Intern> exists = internRepository.existsById(id);

       if(exists.isPresent()){
        throw new IllegalStateException("intern with id"+id+"does not exists");
       }
        internRepository.deleteById((long)id);
    }
}
