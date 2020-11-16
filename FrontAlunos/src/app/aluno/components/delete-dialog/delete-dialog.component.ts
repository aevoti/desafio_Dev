import { Component, Inject } from "@angular/core";
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-delete-dialog',
  templateUrl: './delete-dialog.component.html'
})
export class DeleteDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<DeleteDialogComponent>
  ) {

  }

  public onExclude() {
    this.dialogRef.close(true);
  }

  public onCancel() {
    this.dialogRef.close(false);
  }
}
