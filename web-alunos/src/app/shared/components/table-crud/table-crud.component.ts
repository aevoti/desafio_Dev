import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { LEADING_TRIVIA_CHARS } from '@angular/compiler/src/render3/view/template';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ConfirmationService, ConfirmEventType, MessageService } from 'primeng/api';
import { ActionConfig } from '../../models/action-confg.model';
import { ActionType } from '../../models/action-type.enum';
import { Action } from '../../models/action.model';
import { Column } from '../../models/column.model';

@Component({
  selector: 'app-table-crud',
  templateUrl: './table-crud.component.html',
  styleUrls: ['./table-crud.component.scss'],
  styles: [`
        :host ::ng-deep .p-dialog .product-image {
            width: 150px;
            margin: 0 auto 2rem auto;
            display: block;
        }
    `],
  providers: [MessageService, ConfirmationService]
})
export class TableCrudComponent implements OnInit {

  //Comum
  @Input() values: any[] = [];
  @Input() columns: Column<any>[] = [];
  @Input() actions: Action<any>[] = [];
  @Input() actionConfig: ActionConfig<any>;
  @Input() actionsLength: number = 55;

  // Seleção
  @Input() selectionMode: string;
  @Input() metaKeySelection: boolean;
  @Input() selectWithCheckbox: boolean

  // Expandir linhas
  @Input() expandable: boolean;

  // Exibição
  @Input() showHeader: boolean = true;
  @Output() hideDialogOutput = new EventEmitter<boolean>();
  @Input() showTooltipOnRows: boolean = false;
  showDialog: boolean;
  @Input() titulo: string;

  // Paginação
  @Input() paginator: boolean = true;
  @Input() rows: number;
  @Input() first: number = 0;
  @Input() compactSummary: boolean;
  @Input() notSelectHeaderWithCheckbox: boolean;

  //Interações
  @Input() class: any;
  model: any;
  @Output() reload = new EventEmitter<boolean>();
  @Input() elementosSelecionados: [] = [];
  @Input() service: any;
  @Input() listStringFilter: string[];
  @Input() idNameProperty: string;

  constructor(
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) { }

  ngOnInit() {

  }

  ngOnChanges(event) {
    if (event.listStringFilter) {
      this.listStringFilter = event.listStringFilter.currentValue;
    }
  }

  get fullColspan() {
    return (this.columns && this.columns.length || 0) + (this.actions && this.actions.length ? 1 : 0) + (this.selectWithCheckbox ? 1 : 0) + (this.expandable ? 1 : 0)
  }

  displayValue(col: Column<any>, obj: any) {
    if (col.valueDisplayFn) {
      return col.valueDisplayFn(obj);
    }
    return obj[col.field];
  }

  displayTitle(col: Column<any>, obj: any) {
    if (col.editable) {
      return null;
    }
    if (col.tooltipValue) {
      return col.tooltipValue(obj);
    }
    if (!this.showTooltipOnRows) {
      return null;
    }
    return this.displayValue(col, obj);
  }

  getIcon(action: Action<any>, obj: any) {
    return `pi ${typeof action.icon === 'string' ? action.icon : action.icon(obj)}`;
  }

  getColorButton(action: Action<any>, obj: any) {
    return ` p-button-${typeof action.iconColor === 'string' ? action.iconColor : action.iconColor(obj)}`;
  }

  openNew() {
    this.cleanColumnsValue();
    this.model = null;
    this.showDialog = true;
  }

  hideDialog() {
    this.showDialog = false;
    this.cleanColumnsValue();
  }

  create() {
    const obj = new this.class();
    this.columns.forEach(resp => {
      obj[resp.field] = resp.value;
    });
    if (this.model && this.model[this.idNameProperty]) {
      obj[this.idNameProperty] = this.model[this.idNameProperty];
      this.change(obj);
    } else {
      this.service.insert(obj).subscribe(resp => {
        this.cleanColumnsValue();
        this.reload.emit(true);
        this.hideDialog();
        this.messageService.add({ severity: 'success', summary: 'Confirmado', detail: 'Registro criado com sucesso!' });
      }, error => {
        this.messageService.add({ severity: 'error', summary: 'Erro interno.', detail: 'Ocorreu um erro interno, por favor abra um chamado no Help Desk.' });
      });
    }
  }

  cleanColumnsValue() {
    this.columns.forEach(resp => {
      resp.value = null;
    });
  }

  get(obj?: any) {
    if (obj) {
      this.columns.forEach(resp => {
        resp.value = obj[resp.field]
      });
    }
    this.activeDialog();
  }

  change(obj?: any) {
    this.service.change(obj).subscribe(resp => {
      this.hideDialog();
      this.messageService.add({ severity: 'success', summary: 'Confirmado', detail: 'Registro alterado com sucesso!' });
      this.reload.emit(true);
    }, error => {
      this.messageService.add({ severity: 'error', summary: 'Erro interno.', detail: 'Ocorreu um erro interno, por favor abra um chamado no Help Desk.' });
    });
  }

  activeDialog() {
    this.showDialog = true;
  }

  delete(id: string) {
    this.confirmationService.confirm({
      message: 'Você deseja deletar este registro?',
      header: 'Confirmação de exclusão',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.service.delete(id).subscribe(resp => {
          this.messageService.add({ severity: 'success', summary: 'Confirmado', detail: 'Registro apagado com sucesso!' });
          this.reload.emit(true);
        }, error => {
          this.messageService.add({ severity: 'error', summary: 'Erro interno.', detail: 'Ocorreu um erro interno, por favor abra um chamado no Help Desk.' });
        });
      }
    });
  }

  callAction(obj: any, action: Action<any>) {
    if (action.actionType === ActionType.delete) {
      this.delete(obj[this.idNameProperty])
    } else if (action.actionType === ActionType.change) {
      this.model = obj;
      this.get(obj);
    }
  }
}