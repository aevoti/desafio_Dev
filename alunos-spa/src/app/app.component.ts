import { Component } from '@angular/core';
import { LoadingService } from './services/loading.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public static readonly API_URL = 'https://5000-da686bba-8ec4-47e7-8951-26d7a7e08908.ws-us02.gitpod.io';
  public readonly SWAGGER_URL = AppComponent.API_URL + '/swagger';

  constructor(public loadingService: LoadingService) {}
}
