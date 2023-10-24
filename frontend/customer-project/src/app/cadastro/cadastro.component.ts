import { Component, OnInit, AfterViewInit, ViewChildren, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControlName, FormArray } from '@angular/forms';
import { NgBrazilValidators } from 'ng-brazil';
import { utilsBr } from 'js-brasil';
import { ValidationMessages, GenericValidator, DisplayMessage } from './generic-form-validation';
import { Observable, fromEvent, merge } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { ClienteService } from '../services/cliente.service';
import { Cliente } from './models/cliente';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html'
})
export class CadastroComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  cadastroForm: FormGroup;
  cliente: Cliente;
  formResult: string = '';
  MASKS = utilsBr.MASKS;
  customerId: string = '';

  validationMessages: ValidationMessages;
  genericValidator: GenericValidator;
  displayMessage: DisplayMessage = {};

  constructor(private fb: FormBuilder, 
              private api: ClienteService,
              private route: ActivatedRoute,
              private router: Router) {
    this.customerId = this.route.snapshot.paramMap.get('id');

    this.validationMessages = {
      name: {
        required: 'O Nome é requerido',
        minlength: 'O Nome precisa ter no mínimo 2 caracteres',
        maxlength: 'O Nome precisa ter no máximo 150 caracteres'
      },
      email: {
        required: 'Informe o e-mail',
        email: 'E-mail inválido'
      },
      phone: { 
        required: 'Informe um telefone',
        phone: 'Telefone inválido'
      }
    };

    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  ngOnInit() {
    this.cadastroForm = this.fb.group({
      customerId: [''],
      name: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(150)]],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, NgBrazilValidators.telefone]],
      birthDate: ['', [Validators.required]],
      addressList: this.fb.array([this.criarEndereco()])
    });

    if(this.customerId !== null){
      this.api.getCustomer(this.customerId).subscribe(data => {
        this.cliente = data
      });
    }
  }

  criarEndereco() : FormGroup{
    return this.fb.group({
      postalCode: ['', [Validators.required]],
      street:['', Validators.required],
      streetNumber:['', Validators.required],
      complementaryAddress:[''],
      city:['', Validators.required],
      state:['', Validators.required],
      id:[''],
      customerId:['']
    })
  }

  get addressList(): FormArray{
    return <FormArray> this.cadastroForm.get('addressList');
  }

  adicionarEndereco() {
    this.addressList.push(this.criarEndereco());
  }

  ngAfterViewInit(): void {
    const controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(() => {
      this.displayMessage = this.genericValidator.processarMensagens(this.cadastroForm);
    });
  }

  adicionarCliente() {
    if (this.cadastroForm.dirty && this.cadastroForm.valid) {
      this.cliente = Object.assign({}, this.cliente, this.cadastroForm.value);

      if(this.customerId !== null){
        this.api.putCustomer(this.cliente).subscribe(data => {
          this.formResult = data;
          this.router.navigate(['home']);
        });
      }
      else {
        this.api.postCustomer(this.cliente).subscribe(data => {
          this.formResult = data;
          this.router.navigate(['home']);
        });
      }
    } else {
      this.formResult = 'Não submeteu!!!';
    }
  }

}
