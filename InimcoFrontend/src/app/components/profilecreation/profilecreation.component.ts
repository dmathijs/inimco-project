import { Component, OnInit } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { CreateProfile } from 'src/app/models/Profile';
import { SocialNetwork } from 'src/app/models/SocialNetwork';
import { WrappedProfileResponse } from 'src/app/models/WrappedProfileResponse';
import { ProfileService } from 'src/app/services/profile.service';
import { SocialMediaService } from 'src/app/services/social-media.service';

@Component({
  selector: 'app-profilecreation',
  templateUrl: './profilecreation.component.html',
  styleUrls: ['./profilecreation.component.scss']
})
export class ProfileCreationComponent implements OnInit {

  errors: string[];
  loading: boolean = true;

  supportedSocialMediaChannels: SocialNetwork[];
  activeProfile: WrappedProfileResponse;
  
  constructor(private profileService: ProfileService, private socialMediaService : SocialMediaService) { }

  ngOnInit(): void {
    // Start by fetching supported social media channels for which user can create
    // an account
    this.socialMediaService.getSupportedSocialMedia()
      .pipe(catchError(error => { 
        this.errors  = ["Could not fetch list of supported social media."]; 
        return of([]);}))
      .subscribe(data => { 
        this.supportedSocialMediaChannels = data;

        if(data.length)
          this.errors = null;
          this.loading = false;
      });
  }

  addProfile(profile:CreateProfile){
    this.profileService.createProfile(profile)
    .pipe(catchError(error => { 
      if(Object.values(error?.error?.errors).length){
        this.errors = Object.values(error.error.errors)
      }else{
        this.errors = ['Something went wrong, try again later..']
      }
      
      return of(null);}))
    .subscribe(data => { 
      if(data != null) this.errors = null;
      this.activeProfile = data;
    });
  }

  setErrors($errors: string[]){
    console.log(`setting errors: ${$errors}`);
    this.errors = $errors;
  }
}
