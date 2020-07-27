import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';


@Injectable({ providedIn: 'root' })
export class UrlInterceptor implements HttpInterceptor {

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const baseUrl = environment.apiUrl;

        req = req.clone({
            url: baseUrl + req.url
        });

        return next.handle(req);
    }

}
