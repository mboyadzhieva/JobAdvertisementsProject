import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class ErrorInterceptorService implements HttpInterceptor {
  constructor(private toastrService: ToastrService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      retry(1),
      catchError((error) => {
        let msg;
        if (error.status === 401) {
          // refresh token or navigate to login
          msg = "Your token has expired or you're not logged in!";
        } else if (error.status === 404) {
          // custom error msg
          msg = '404 Not Found!';
        } else if (error.status === 400) {
          msg = '400 Bad Request!';
        } else {
          msg = 'Something went wrong. Try again!';
        }

        this.toastrService.error(msg);
        return throwError(error);
      })
    );
  }
}
