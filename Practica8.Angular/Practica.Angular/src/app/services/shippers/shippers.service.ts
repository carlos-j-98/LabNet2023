import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Shippers } from 'src/app/app-modules/shippers/shippers-models/Shippers';
import { environment } from 'src/environments/environment';
import { ApiResponse } from 'src/app/app-modules/shippers/shippers-models/ApiResponse';

@Injectable({
  providedIn: 'root'
})
export class ShippersService {
  endpoint: string = environment.urlBase + "/Shipper";

  private shippersSubject: BehaviorSubject<Shippers[]> = new BehaviorSubject<Shippers[]>([]);
  public shippers$: Observable<Shippers[]> = this.shippersSubject.asObservable();

  constructor(private http: HttpClient) { }

  getShippers(): Observable<Shippers[]> {
    return this.http.get<Shippers[]>(this.endpoint);
  }
  public getShippersId(id: number): Observable<ApiResponse<Shippers>> {
    return this.http.get<Shippers>(this.endpoint + "/" + id)
      .pipe(
        map(data => ({ message: 'Succes', data })),
        catchError(this.handleError)
      );
  }
  public deleteShippers(id: number): Observable<ApiResponse<string>> {
    return this.http.delete<string>(this.endpoint+ "/" + id)
      .pipe(
        map(data => ({ message: 'Succes', data})),
        catchError(this.handleError)
      );
  }
  updateShipper(shipper: Shippers): Observable<Shippers> {
    return this.http.put<Shippers>(`${this.endpoint}/${shipper.ID}`, shipper).pipe(
      tap(response => {
        this.updateShippersList();
      }),
      catchError(this.handleError)
    );
  }
  
  public createShippers(ship: Shippers): Observable<Shippers> {
    return this.http.post<Shippers>(this.endpoint, ship)
      .pipe(
        tap(response => {
          const shippers = this.shippersSubject.value.slice();
          const index = shippers.findIndex(s => s.ID === response.ID);
          if (index > -1) {
            shippers.splice(index, 1, response);
          }
          this.shippersSubject.next(shippers);
        }),
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse): Observable<never> {
    return throwError('Ha ocurrido un error en la solicitud.');
  }

  notifyShippersChanged(shippers: Shippers[]) {
    this.shippersSubject.next(shippers);
  }
  updateShippersList(){
    this.getShippers().subscribe({
      next: (response: Shippers[]) => {
        this.notifyShippersChanged(response);
      }
    });
  }
}
