export class Column<T> {
    value: any;
    header: string;
    headerClass?: string;
    field?: string;
    valueDisplayFn?: (value: T) => any;
    width?: string;
    tooltipTitle?: string;
    tooltipValue?: (value: T) => string;
    sortable?: boolean;
    editable?: (obj: T) => boolean;
    styleClass?: (obj: T) => string | any;
    editConfig?: ColumnEditConfig<T>;
  }
  
  export class ColumnEditConfig<T> {
    inputType: 'text' | 'dropdown' | 'decimal' | 'checkbox' | 'number' | 'autocomplete' | 'datepicker' | 'mask';
    disabled?: (obj: T) => boolean;
    readonly?: (obj: T) => boolean;
  
    textConfig?: ColumnEditTextConfig;
    dropdownConfig?: ColumnEditDropdownConfig<T>;
    decimalConfig?: ColumnEditDecimalConfig;
    checkboxConfig?: ColumnCheckboxConfig<T>;
    numberConfig?: ColumnEditNumberConfig;
    autocompleteConfig?: ColumnEditAutocompleteConfig;
    datepickerConfig?: ColumnDatepickerConfig;
    maskConfig?: ColumnMaskConfig;
  }
  
  export class ColumnEditTextConfig {
    maxlength?: number;
    onKeyup?: (text: string) => void;
  }
  
  export class ColumnEditDropdownConfig<T> {
    options: (obj: T) => any[];
    optionValueField?: string;
    optionLabelField?: string;
    defaultOption?: string;
    filter?: boolean;
    onChange?: (obj: T) => void;
  }
  
  export class ColumnEditDecimalConfig  {
    fixedSuffix?: 'percent' | 'days';
    options: DecimalOptions;
    onKeyup?: (text: string) => void;
  }
  
  export class ColumnCheckboxConfig<T> {
    ngModelChange?: (event: boolean, obj: T) => void;
  }
  
  export type DecimalOptions = {
    prefix?: string,
    suffix?: string,
    thousands?: string,
    decimal?: string,
    precision?: number,
    align?: 'left' | 'right'
  };
  
  export class ColumnEditNumberConfig {
    suffix?: 'percent' | 'days';
    maxlength?: number;
    onKeyup?: (text: string) => void;
  }
  
  export class ColumnEditAutocompleteConfig {
    suggestions: () => any[];
    field: string;
    complete: (text: string) => void;
    multiple?: boolean;
    selectMethod?: (event: any) => any;
    unselectMethod?: (event: any) => any;
  }
  
  export class ColumnDatepickerConfig {
    showTime?: boolean;
  }
  
  export class ColumnMaskConfig {
    label?: string;
    name: string;
    mask: string;
    autoClear: boolean;
  }
  