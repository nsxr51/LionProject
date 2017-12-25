import { Component, OnInit,Output,Input,EventEmitter } from '@angular/core';
import { NetworkService } from '../../services/network.service';

@Component({
  selector: 'app-pc-list-component',
  templateUrl: './pc-list-component.component.html',
  styleUrls: ['./pc-list-component.component.css']
})
export class PcListComponentComponent implements OnInit {
  @Input() pcs;
  @Input() state;
  PcSelected;
  @Output() PcSelectedChanged = new EventEmitter();

  constructor(netservice:NetworkService) { 

  }

  ngOnInit() {
  }
  
  onAfterToggle(event){
    console.log("onAfterToggle : "+event.collapsed);
    if(!event.collapsed){
      this.state="pctlist";
    }
  }
  onRowSelect(event){
     this.PcSelectedChanged.emit(this.PcSelected);
  }
  onRowUnselect(event){
    console.log(this.PcSelected);
    this.PcSelectedChanged.emit(this.PcSelected);    
  }
}
