import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { TabShippersComponent } from './shippers-components/tab-shippers/tab-shippers.component';
import { FormShippersComponent } from './shippers-components/form-shippers/form-shippers.component';
import { TableShippersComponent } from './shippers-components/table-shippers/table-shippers.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSelectModule } from '@angular/material/select';
import { NotifyComponent } from './shippers-components/notify/notify.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



@NgModule({
  declarations: [
    TabShippersComponent,
    FormShippersComponent,
    TableShippersComponent,
    NotifyComponent
  ],
  imports: [
    CommonModule,
    MatTabsModule,
    FormsModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatListModule,
    MatTableModule,
    MatIconModule,
    HttpClientModule,
    MatSnackBarModule,
    MatSelectModule,
    BrowserAnimationsModule
  ],
  providers:[
    NotifyComponent
  ],
  exports:[
    TabShippersComponent
  ]
})
export class ShippersModule { }
