import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Purchases } from '../models/purchases';

@Injectable({
  providedIn: 'root'
})
export class PurchaseServiceService {
  private url = "Purchase";
  constructor(private http: HttpClient) { }

  public getPurchases() : Observable<Purchases[]> {
    return this.http.get<Purchases[]>(`${environment.apiUrl}/${this.url}`);
  }
}