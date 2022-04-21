import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FormGroup, FormControl, FormArray } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { FeedbackService } from 'src/services/feedback.service';
import { feedback } from 'src/services/feedback';
import { convertActionBinding } from '@angular/compiler/src/compiler_util/expression_converter';


@Inject(FeedbackService)
@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent {

  alert:boolean = false;
  feedbackForm = this.formBuilder.group({
    id: [''],
    first_name: [''],
    last_name: [''],
    email: [''],
    suggestions: ['']

  });

  feedback!: feedback;

  constructor(
    private formBuilder: FormBuilder,
    private FeedbackService: FeedbackService,
   ) { }


  onSubmit(data:any) {
    console.log(data);
    this.FeedbackService.submitUser(data).subscribe(result=>{});
    // alert('!!Feedback Submitted Successfully!!');
    this.alert = true;
    //this.feedback.reset({});
 }
  closeAlert(){
    this.alert = false;
  }

}
