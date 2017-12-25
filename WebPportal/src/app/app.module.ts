import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { NetworkService } from './services/network.service';
import { AppComponent } from './app.component';
import { ProjectListComponentComponent } from './components/project-list-component/project-list-component.component';
import {DataTableModule,SharedModule,SliderModule,DropdownModule,MultiSelectModule} from 'primeng/primeng';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { PcListComponentComponent } from './components/pc-list-component/pc-list-component.component';
import { ExtentionsChoiceComponent } from './components/extentions-choice/extentions-choice.component';
import {ListboxModule,PanelModule,CheckboxModule} from 'primeng/primeng';
import { SignalRModule } from 'ng2-signalr';
import { SignalRConfiguration } from 'ng2-signalr';
import {MenubarModule,MenuItem} from 'primeng/primeng';
import { MenuBarComponent } from './components/menu-bar/menu-bar.component';
import {FileUploadModule,DialogModule} from 'primeng/primeng';
import {MessagesModule} from 'primeng/primeng';
import {MessageModule} from 'primeng/primeng';
export function createConfig(): SignalRConfiguration {
  const c = new SignalRConfiguration();
  c.hubName = 'LionWebHub';
  c.qs = { user: 'lior' };
  c.url = 'http://localhost:7331';
  c.logging = false;
  return c;
}
@NgModule({
  declarations: [
    AppComponent,
    ProjectListComponentComponent,
    PcListComponentComponent,
    ExtentionsChoiceComponent,
    MenuBarComponent,  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    DataTableModule,
    SharedModule,
    SliderModule,
    ListboxModule,
    CheckboxModule,
    PanelModule,
    MenubarModule,
    MessagesModule,
    MessageModule,
    FileUploadModule,
    DialogModule,
    DropdownModule,MultiSelectModule,
    SignalRModule.forRoot(createConfig)
  ],
  providers: [NetworkService],
  bootstrap: [AppComponent]
})
export class AppModule { }
