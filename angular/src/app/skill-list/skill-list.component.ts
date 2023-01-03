import { Component, OnInit } from '@angular/core';
import { Skill } from '../models/skill';
import { SkillsService } from '../services/skills.service';

@Component({
  selector: 'app-skill-list',
  templateUrl: './skill-list.component.html',
  styleUrls: ['./skill-list.component.scss']
})
export class SkillListComponent   {

  skills: Skill[] = [

  ];



  constructor() { }

  
  
}
