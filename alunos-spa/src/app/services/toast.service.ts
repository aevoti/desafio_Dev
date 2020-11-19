import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  constructor(private snackBar: MatSnackBar) { }

  private showToast(message: string, hasError: boolean): void {
    this.snackBar.open(message, null, {
      duration: 3500,
      horizontalPosition: 'right',
      verticalPosition: 'top',
      panelClass: hasError ? ['red-snackbar'] : []
    });
  }

  public showSuccessToast(message): void {
    this.showToast(message, false);
  }

  public showErrorToast(): void {
    this.showToast('Occoreu um erro!', true);
  }
}
