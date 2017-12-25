import { Component, OnInit,Input, Output, EventEmitter } from '@angular/core';
import { NetworkService } from '../../services/network.service';

@Component({
  selector: 'app-project-list-component',
  templateUrl: './project-list-component.component.html',
  styleUrls: ['./project-list-component.component.css']
})

export class ProjectListComponentComponent implements OnInit {
  @Input()
  projects;
  @Input()
  state;
  @Output() ProjectSelectedChanged = new EventEmitter();
  checked: boolean = false;
  selectedProject;
  constructor(netservice:NetworkService) {

   }

  ngOnInit() {
  }
  onRowSelect(event) {
    console.log(this.selectedProject);
    this.checked=true;
    this.ProjectSelectedChanged.emit(this.selectedProject);
}

onAfterToggle(event){
  console.log("onAfterToggle : "+event.collapsed);
  if(!event.collapsed){
    this.state="projectlist";
  }
}
}
