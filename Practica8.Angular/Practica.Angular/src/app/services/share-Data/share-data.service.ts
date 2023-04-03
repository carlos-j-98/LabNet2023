import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShareDataService {
  private idSource = new Subject<string>();
  id$ = this.idSource.asObservable();
  private idTabSource = new Subject<number>();
  idTab$ = this.idTabSource.asObservable();
  constructor() { }
  updateId(id:string){
    this.idSource.next(id);
  }
  updateTabP(id: number){
    this.idTabSource.next(id);
  }
}
