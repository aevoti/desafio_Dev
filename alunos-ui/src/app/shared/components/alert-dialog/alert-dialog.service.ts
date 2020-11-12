import { Injectable } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';

import { AlertDialogComponent } from './alert-dialog.component';
import { AlertDialogData } from './alert-dialog-data';



@Injectable({
  providedIn: 'root'
})
export class AlertDialogService {

  private dialogRef: MatDialogRef<AlertDialogComponent>;

  constructor(public dialog: MatDialog) { }

  openDialog(data: AlertDialogData, additionalDialogConfigData?: any): MatDialogRef<AlertDialogComponent> {

    if (this.dialogRef) {
      this.dialogRef.close();
    }
    
    this.dialogRef = this.dialog.open(AlertDialogComponent, {
      width: '500px',
      data,
      ...additionalDialogConfigData,
      panelClass: 'myapp-no-padding-dialog'
    });

    this.dialogRef.afterClosed().subscribe(result => {
    });

    return this.dialogRef;
  }

}
