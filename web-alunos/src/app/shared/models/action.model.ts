import { Injectable, ViewChild } from "@angular/core";
import { TableCrudComponent } from "../components/table-crud/table-crud.component";
import { ActionType } from "./action-type.enum";

@Injectable()

export class Action<T> {
  title: string;
  iconType: 'fa' | 'glyphicons' | 'pi';
  icon: (string | ((value) => string));
  iconColor: (string | ((value) => string));
  animation?: (string | ((value) => string));
  handler?: (obj: T, rowIndex?: number) => any;
  isHidden?: (obj: T, index?: number) => boolean; 
  routerLink?: (obj: T) => string | any[];
  permission?: string | string[];
  actionType: ActionType;
}



