import { Component } from '@angular/core';
import { LoadingService } from './services/loading.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public static readonly API_URL = 'https://5000-ea9d0ded-1fb3-4371-b6f8-1e039a08b439.ws-us02.gitpod.io';
  public readonly SWAGGER_URL = AppComponent.API_URL + '/swagger';

  constructor(public loadingService: LoadingService) {}
}
