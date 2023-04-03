import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ShippersService } from 'src/app/services/shippers/shippers.service';
import { Shippers } from '../../shippers-models/Shippers';
import { ShareDataService } from 'src/app/services/share-Data/share-data.service';
import { catchError, throwError } from 'rxjs';
import { NotifyComponent } from '../notify/notify.component';

@Component({
  selector: 'app-table-shippers',
  templateUrl: './table-shippers.component.html',
  styleUrls: ['./table-shippers.component.scss']
})
export class TableShippersComponent implements OnInit {
  shippers: Shippers[] = [];
  displayedColumns: string[] = ['id', 'name', 'phone', 'actions'];
  dataSource = new MatTableDataSource(this.shippers);
  showTryAgain: boolean = false;

  constructor(private shipService: ShippersService, private shareService: ShareDataService, private notify: NotifyComponent) { }

  ngOnInit(): void {
    this.shipService.shippers$.subscribe(ship => {
      this.shippers = ship;
      this.getShippers();
    })

  }
  update(id: string): void {
    this.shareService.updateId(id);
    this.shareService.updateTabP(parseInt(id));
  }
  delete(id: number): void {
    this.shipService.deleteShippers(id)
      .pipe(
        catchError((error) => {
          if(error.status === 404 ){
            this.notify.showError(error);
          }else{
            this.notify.showError(error);
          }
          return throwError(() => error);
        })
      )
      .subscribe({
        next: (response) => {
          this.shipService.updateShippersList();
          this.notify.showSuccess("El shipper fue eliminado con exito");
        }
      });
  }

  getShippers(): void {
    this.shipService.getShippers().subscribe({
      next: (response: Shippers[]) => {
        this.dataSource.data = response;
        this.showTryAgain = false;
      },
      error: (error) => {
        this.showTryAgain = true;
        if(error.status === 0){
          this.notify.showError("No se pudo establecer conexion con la base de datos");
        }else if (error.status === 404){
          this.notify.showError("No se encontraron elementos que cumplan con la peticion indicada");
        }else{
          this.notify.showError("La peticion fue incorrecta");
        }
      }
    });
  }

  tryAgain(): void {
    this.getShippers();
  }
}
