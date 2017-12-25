import { Injectable } from '@angular/core';
import { HttpClient , HttpRequest, HttpEventType, HttpResponse} from '@angular/common/http';
import { SignalR, BroadcastEventListener, IConnectionOptions } from 'ng2-signalr';
import { SignalRModule } from 'ng2-signalr';
import { SignalRConnection } from 'ng2-signalr/src/services/connection/signalr.connection';
import { saveAs } from 'file-saver/FileSaver';

@Injectable()
export class NetworkService {
  conx:SignalRConnection;
  constructor(private http:HttpClient,private _signalR: SignalR) { }
  
  GetProjectList():Promise<any>{
    var promise = new Promise((resolve, reject) => {
        var url = "http://localhost:7331/api/configuration/GetProjectList";
        this.http.get(url).subscribe (
          data => {
            //console.log("loading confiduration raw: " + JSON.stringify(data));
            resolve(data);
          },
          err => {
            reject([]);
          }
        );
    });
    return promise;
  }
  GetPcList():Promise<any>{
    var promise = new Promise((resolve, reject) => {
        var url = "http://localhost:7331/api/configuration/GetPcList";
        this.http.get(url).subscribe (
          data => {
            //console.log("loading confiduration raw: " + JSON.stringify(data));
            resolve(data);
          },
          err => {
            reject([]);
          }
        );
    });
    return promise;
  }

  ProgreesEvent(){
    let options: IConnectionOptions = { hubName: 'LionWebHub' };
    this.conx=this._signalR.createConnection(options);
    let onMessageSent$ = new BroadcastEventListener<string>('broadcastMessage');
    this.conx.listen(onMessageSent$);
    onMessageSent$.subscribe((chatMessage: string) => {
     console.log(chatMessage);
});
      this.conx.start().then((e)=>{
      console.log("e : "+e);
    })  

  }
SendMessage(){
  this.conx.invoke('ServerMethodName').then((data: string) => {
    console.log(data);
});
}

DownloadFile(){
  console.log("download file");
  var url = "http://localhost:7331/api/configuration/downloadXmlFile";
  this.http.get(url).subscribe (
    data => {
      console.log(data);
      this.saveToFileSystem(data)
    },
    err => {
     console.log("err : "+err);
    });
}

private saveToFileSystem(response) {
  const filename = "pcs.xml";
  const blob = new Blob([response], { type: 'text/plain' });
  saveAs(blob, filename);
}
}
