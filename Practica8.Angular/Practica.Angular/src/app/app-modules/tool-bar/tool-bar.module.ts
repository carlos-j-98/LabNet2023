import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToolBarComponent } from './tool-bar/tool-bar.component';
import { MatToolbarModule } from '@angular/material/toolbar';

@NgModule({
  declarations: [
    ToolBarComponent
  ],
  imports: [
    CommonModule,
    MatToolbarModule
  ],
  exports:[
    ToolBarComponent
  ]
})
export class ToolBarModule { }
