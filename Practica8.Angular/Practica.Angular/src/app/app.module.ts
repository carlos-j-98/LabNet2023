import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToolBarModule } from './app-modules/tool-bar/tool-bar.module';
import { ShippersModule } from './app-modules/shippers/shippers.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToolBarModule,
    ShippersModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
