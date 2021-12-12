import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { catchError, of } from 'rxjs';
import { CreateProfile } from 'src/app/models/Profile';
import { SocialAccountCreate } from 'src/app/models/SocialAccount';
import { SocialNetwork } from 'src/app/models/SocialNetwork';
import { ProfileService } from 'src/app/services/profile.service';
import { SocialMediaService } from 'src/app/services/social-media.service';

@Component({
  selector: 'app-profilecreationform',
  templateUrl: './profilecreationform.component.html',
  styleUrls: ['./profilecreationform.component.scss']
})
export class ProfilecreationformComponent implements OnInit {

  profileForm = this.fb.group({
    firstName: [""],
    lastName: [""],
    socialSkills: this.fb.array([]),
    socialAccounts: this.fb.array([])
  });
  
  @Input() supportedSocialMediaChannels: SocialNetwork[];
  @Output() onSubmitAccount = new EventEmitter<CreateProfile>();
  
  constructor(private fb: FormBuilder) { }
  
  ngOnInit(): void {
  }

  get socialAccounts() {
    return this.profileForm.controls["socialAccounts"] as FormArray;
  }

  get socialSkills() {
    return this.profileForm.controls["socialSkills"] as FormArray;
  }

  // Create social accounts field corresponding with supported social media channels
  ngOnChanges(changes: SimpleChanges) {
      const supportedSocials = changes["supportedSocialMediaChannels"]?.currentValue?.length;

      if(!supportedSocials) return;

      while(this.socialAccounts.length < supportedSocials){
        const currentIndex = this.socialAccounts.length;
        this.socialAccounts.push(this.fb.group({
          label: this.supportedSocialMediaChannels[currentIndex].name,
          type: this.supportedSocialMediaChannels[currentIndex].key,
          address: ""
        }));
      }
  }

  addSocialSkill(){
    this.socialSkills.push(this.fb.control(""));
  }

  deleteSocialSkill(index){
    this.socialSkills.removeAt(index);
  }

  onSubmit() {
    this.onSubmitAccount.emit({
        firstName: this.profileForm.controls["firstName"].value,
        lastName: this.profileForm.controls["lastName"].value,
        socialAccounts: this.profileForm.controls["socialAccounts"].value.map(sa => ({
          type:sa.type,
          address:sa.address
        })).filter(sa => sa.address !== ""),
        socialSkills: this.profileForm.controls["socialSkills"].value.filter(ss => ss !== "")
    })
  }
}
