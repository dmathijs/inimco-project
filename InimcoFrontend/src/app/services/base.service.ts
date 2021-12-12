export class BaseService {
	protected apiBaseUrl = "https://localhost:7203/api/";
	protected controllerUrl = this.apiBaseUrl;

	constructor(controller: string){
		this.controllerUrl = `${this.apiBaseUrl}${controller}`;
	}
}