import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SocialNetwork } from '../models/SocialNetwork';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class SocialMediaService extends BaseService {

  constructor(private httpClient: HttpClient) { 
    super("socialnetworks");
  }

  getSupportedSocialMedia() : Observable<SocialNetwork[]>{
    return this.httpClient.get<SocialNetwork[]>(this.controllerUrl);
  }
}
