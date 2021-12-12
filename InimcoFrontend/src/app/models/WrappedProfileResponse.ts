import { CreatedProfile } from "./Profile";

export interface WrappedProfileResponse {
	name: string;
	reversedName: string;

	numberOfVowelsInFirstAndLastName: number;
	numberOfConsonantsInFirstAndLastName: number;

	originalProfile: CreatedProfile;
}