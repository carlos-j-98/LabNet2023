import { Component, OnInit  } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

@Component({
  selector: 'app-notify',
  templateUrl: './notify.component.html',
  styleUrls: ['./notify.component.scss']
})
export class NotifyComponent implements OnInit {
  constructor( private snackBar: MatSnackBar) { }

  ngOnInit(): void {
  }
  showSuccess(message: string): void {
    const config: MatSnackBarConfig = {
      duration: 3000,
      horizontalPosition: 'center',
      verticalPosition: 'top',
      panelClass: ['success-snackbar']
    };
    this.snackBar.open(message, '', config);
  }

  showError(message: string): void {
    const config: MatSnackBarConfig = {
      duration: 5000,
      horizontalPosition: 'center',
      verticalPosition: 'top',
      panelClass: ['error-snackbar']
    };
    this.snackBar.open(message, '', config);
  }
}
