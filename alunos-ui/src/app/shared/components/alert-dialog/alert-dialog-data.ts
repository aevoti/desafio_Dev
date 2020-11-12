export enum AlertType {
    SUCCESS,
    WARNING,
    DANGER,
    INFO
}
export class AlertDialogData {
    title: string;
    message: string;
    showOKBtn = false;
    showCancelBtn = false;
    alertType: AlertType;
}
