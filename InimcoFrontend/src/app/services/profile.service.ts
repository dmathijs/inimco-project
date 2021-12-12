import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { CreateProfile } from '../models/Profile';
import { WrappedProfileResponse } from '../models/WrappedProfileResponse';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})

export class ProfileService extends BaseService {

  constructor(private httpClient: HttpClient) { 
    super("profiles");
  }

  createProfile(profile: CreateProfile): Observable<WrappedProfileResponse> {
      return this.httpClient.post<WrappedProfileResponse>(this.controllerUrl, profile, {headers:new HttpHeaders({
        "Content-Type": 'application/json'})}
      );
  }
}
