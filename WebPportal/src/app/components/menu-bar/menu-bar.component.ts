import { Component, OnInit ,Output,EventEmitter} from '@angular/core';
import {MenubarModule,MenuItem, Message} from 'primeng/primeng';
import { NetworkService } from '../../services/network.service';

@Component({
  selector: 'app-menu-bar',
  templateUrl: './menu-bar.component.html',
  styleUrls: ['./menu-bar.component.css']
})
export class MenuBarComponent implements OnInit {

  constructor(private netservice:NetworkService) 
  {

  }
  @Output()
  authorClick: EventEmitter<String> = new EventEmitter<String>(); //creating an output event
  items: MenuItem[];
  display:boolean=false;
  msgs: Message[] = [];
  
  ngOnInit() {
      this.items = [
          {
              label: 'Pc\'s list File',
              items: [{
                      label: 'New', 
                      icon: 'fa-plus',
                      items: [
                          {label: 'list',
                           command:(event)=>{
                             console.log(event);
                             this.display=true;
                           }  
                        },
                      ]
                  },
                  {
                    icon:'fa-download',
                    label: 'Download File',
                command:(event)=>{
                  this.netservice.DownloadFile();
                }},
              ]
          },
          {
              label: 'Edit',
              icon: 'fa-edit',
              items: [
                  {label: 'Undo', icon: 'fa-mail-forward'},
                  {label: 'Redo', icon: 'fa-mail-reply'}
              ]
          },
          {
            label: 'Actions',
            items:[
              {label:'Copy to pc\'s',icon:'fa-paper-plane-o',command:(event)=>{
                console.log("send files");
                this.authorClick.emit("jkjk"); //emmiting the event.
              }}
            ]
          }
      ];
  }

  onBasicUpload(event){
        this.msgs = [];
        this.msgs.push({severity:'success', summary:'Uplaod..', detail:'upload successful'});
        this.display = false;
  }
}
