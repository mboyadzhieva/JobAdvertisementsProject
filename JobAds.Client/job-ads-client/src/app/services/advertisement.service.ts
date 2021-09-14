import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Advertisement } from '../models/Advertisement';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class AdvertisementService {
  private adPath = environment.apiUrl + '/advertisements';

  constructor(private http: HttpClient, private authService: AuthService) {}

  create(data): Observable<Advertisement> {
    return this.http.post<Advertisement>(this.adPath, data);
  }

  getAdvertisements(): Observable<Array<Advertisement>> {
    return this.http.get<Array<Advertisement>>(this.adPath);
  }

  getAdvertisementById(id): Observable<Advertisement> {
    return this.http.get<Advertisement>(this.adPath + `/${id}`);
  }

  editAdvertisement(data) {
    return this.http.put(this.adPath, data);
  }

  deleteAdvertisement(id) {
    return this.http.delete(this.adPath + `/${id}`);
  }
}
