import { Component, OnInit, Inject } from '@angular/core';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { AlertDialogData, AlertType } from './alert-dialog-data';


@Component({
  selector: 'aln-alert-dialog',
  templateUrl: './alert-dialog.component.html',
  styleUrls: ['./alert-dialog.component.scss']
})
export class AlertDialogComponent implements OnInit {

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: AlertDialogData,
    private dialogRef: MatDialogRef<AlertDialogComponent>) { }

  close() {
    this.dialogRef.close(true);
  }

  ngOnInit(): void {
  }

  getTitleColor(): string {
    switch (this.data.alertType) {
      case AlertType.SUCCESS:
        return '#00C853'
      case AlertType.DANGER:
        return '#D32F2F'
      case AlertType.WARNING:
        return '#FF6D00'
      case AlertType.INFO:
        return '#00BFA5'
    }
  }

  getType(): string {
    switch (this.data.alertType) {
      case AlertType.SUCCESS:
        return 'success'
      case AlertType.DANGER:
        return 'danger'
      case AlertType.WARNING:
        return 'warning'
      case AlertType.INFO:
        return 'info'
    }
  }
  getTextColor(): string {
    return '#00E676'
  }

}
