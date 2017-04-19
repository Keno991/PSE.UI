import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './PSEMainComponent/app.component';
import { ImgService } from './ImagesPulling/img.service';

@NgModule({
  imports:      [ BrowserModule, HttpModule, FormsModule ],
  declarations: [AppComponent],
  providers: [ImgService],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }