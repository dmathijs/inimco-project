
interface SocialAccount {
	address?: string;
}

export interface SocialAccountResponse extends  SocialAccount {
	type: string;
}

export interface SocialAccountCreate extends SocialAccount {
	label: string;
	type: number;
}