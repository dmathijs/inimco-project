import { SocialAccountCreate, SocialAccountResponse } from './SocialAccount'

interface Profile {
	firstName: string;
	lastName: string;

	socialSkills: string[];
}

export interface CreateProfile extends Profile{
	socialAccounts: SocialAccountCreate[];
}

export interface CreatedProfile extends Profile {
	socialAccounts: SocialAccountResponse[];
}