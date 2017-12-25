import { Component, OnInit,Input,Output,EventEmitter } from '@angular/core';

@Component({
  selector: 'app-extentions-choice',
  templateUrl: './extentions-choice.component.html',
  styleUrls: ['./extentions-choice.component.css']
})

export class ExtentionsChoiceComponent implements OnInit {
  @Input()   extension:any;
  @Input()  state;
  @Output() ExtensionSelectedChanged = new EventEmitter();
  checked:boolean=false;
  selectedExtension;
  constructor() { 
    console.log("E : "+ this.extension);
  }

  ngOnInit() {
  }
  onChange(){
    this.ExtensionSelectedChanged.emit(this.selectedExtension);
    this.checked=true;
  }
}
