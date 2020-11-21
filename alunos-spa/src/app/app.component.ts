import { Component } from '@angular/core';
import { LoadingService } from './services/loading.service';
import { environment } from './../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public static readonly API_URL = environment.apiUrl;
  public readonly SWAGGER_URL = AppComponent.API_URL + '/swagger';

  constructor(public loadingService: LoadingService) {}
}
