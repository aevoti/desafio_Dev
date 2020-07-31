import { HttpHeaders, HttpClient, HttpResponse } from "@angular/common/http";
import { KeyValue } from '@angular/common';
import { Observable } from "rxjs";

import { environment } from '../../../../environments/environment';

export class HttpService<T> {
  protected httpOptions: {
    headers: HttpHeaders;
  }

  constructor(protected endpoint: string, protected http: HttpClient) {
    this.httpOptions = { headers: this.getHeaders() };
    this.endpoint = environment.baseUrl + endpoint;
  }

  getAll(queryParams?: KeyValue<string, string>[]): Observable<HttpResponse<T[]>> {
    let params: string;

    if (queryParams) { params = this.buildParams(queryParams); }

      return this.http.get<T[]>(`${this.endpoint}${params}`, { observe: 'response', headers: new HttpHeaders({
        "Access-Control-Expose-Headers": "X-Pagination"
      }) });
  }

  get(id: number): Observable<T> {
    return this.http.get<T>(`${this.endpoint}/${id}`);
  }

  post(item: T | any): Observable<T> {
    return this.http.post<T>(this.endpoint, item, this.httpOptions);
  }

  put(id: number, item: T | any): Observable<T> {
    return this.http.put<T>(`${this.endpoint}/${id}`, item, this.httpOptions);
  }

  delete(id: number): Observable<T> {
    return this.http.delete<T>(`${this.endpoint}/${id}`);
  }

  private getHeaders(): HttpHeaders {
    const headers = new HttpHeaders({
      "Content-Type": "application/json; charset=utf-8",
    });

    return headers;
  }

  protected buildParams(queryParams: KeyValue<string, string>[]) {
    const p = '?' + queryParams
      .map(queryParam => {
        if (queryParam.value !== null && queryParam.value !== '') {
          return `${queryParam.key}=${queryParam.value}`;
        }
      })
      .filter(q => q !== undefined)
      .join('&');

    return p;
  }
}
