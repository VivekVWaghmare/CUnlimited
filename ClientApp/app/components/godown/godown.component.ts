import { Component, Input, Inject,  OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';  
import { Router, ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';  
import { StockService } from '../../common/services/stock.service';
import { DepartmentService } from '../../common/services/department.service';

@Component({
    selector: 'godown',
    templateUrl: './godown.component.html',
    styleUrls: ['./godown.component.css']
})

export class GodownComponent implements OnInit {
    
    public Inventory: InventoryMaster [] = [];  
    public item = <InventoryMaster> {
        inventoryID: 0,  
        itemName: "",
        departmentId:0
    };
    public department: Department [] =[];
    // to hide and Show Insert/Edit   
    AddTable: Boolean = false;  
    // To stored Informations for insert/Update and Delete  
    public sInventoryID : number = 0;  
    public sItemName = "";  
    public sStockQty : number  = 0;  
    public sReorderQty : number = 0; 
    public soutQuantity : number = 0; 
    public sPriorityStatus: boolean = false;  
    public bseUrl: string = "";  
      
    public schkName: string = "";  
    myName: string = "";  

    constructor(private http: Http, private _router: Router, private _stockService: StockService,
        private _departmentService: DepartmentService, @Inject('BASE_URL')base_url: string)
    {
        this.myName = "Vivek";  
        this.AddTable = false;  
        this.bseUrl = base_url; 
    }

    ngOnInit(): void {
        //throw new Error("Method not implemented.");
        this._departmentService.getDepartment().subscribe(
            data => this.department= data  
        ) 
        this._stockService.getStock().subscribe(
            data => this.Inventory= data  
        ) 
    }

    getData(){
        this._stockService.getStock().subscribe(
            data => this.Inventory= data  
        ) 
    }

    AddInventory() {   
        this.AddTable = true;  
        // To stored Student Informations for insert/Update and Delete  
        this.sInventoryID = 0;  
        this.sItemName = "";  
        this.sStockQty = 50;  
        this.sReorderQty = 50;
        this.soutQuantity=0;  
        this.sPriorityStatus = false;  
    }  

    // to show form for edit Inventory Information  
    editInventoryDetails(INVY : InventoryMaster)
    {
        this.AddTable = true;  
        console.log(INVY);
        this.item = INVY;
        this.item.inQuantity =0;
        this.item.outQuantity =0;
        console.log(this.item);
    }
    editInventoryDetails1(inventoryIDs : number, itemNames : string, stockQtys : number, reorderQtys : number , outQtys : number ,  priorityStatus : number) {   
        this.AddTable = true;  
        this.sInventoryID = inventoryIDs;  
        this.sItemName = itemNames;  
        this.sStockQty = stockQtys;  
        this.sReorderQty = reorderQtys; 
        this.soutQuantity = outQtys; 
        if (priorityStatus == 0)  
        {  
            this.sPriorityStatus = false;  
        }  
        else {  
            this.sPriorityStatus = true;  
        }  
         
    }  

    // If the InventoryId is 0 then insert the Inventory infromation using post and if the Inventory id is greater than 0 then edit using put mehod  
    addInventoryDetails1(inventoryIDs: number, itemNames: string, stockQtys: number, reorderQtys: number, priorityStatus: boolean) {  
        var pStatus: number = 0;  
          
        this.schkName = priorityStatus.toString();  
        if (this.schkName == "true") {  
            pStatus = 1;  
        }  
        var headers = new Headers();  
        headers.append('Content-Type', 'application/json; charset=utf-8');  
        if (inventoryIDs == 0) {  
            this.http.post(this.bseUrl + 'api/InventoryMasterAPI/', JSON.stringify({ InventoryID: inventoryIDs, ItemName: itemNames, StockQty: stockQtys, ReorderQty: reorderQtys, PriorityStatus: pStatus }),  
                { headers: headers }).subscribe(  
                response => {  
                    this.getData();  
  
                }, error => {  
                }  
                );   
              
        }  
        else {  
            this.http.put(this.bseUrl + 'api/InventoryMasterAPI/' + inventoryIDs, JSON.stringify({ InventoryID: inventoryIDs, ItemName: itemNames, StockQty: stockQtys, ReorderQty: reorderQtys, PriorityStatus: pStatus }), { headers: headers })  
                .subscribe(response => {  
                    this.getData();  
  
                }, error => {  
                }  
                );   
             
        }  
        this.AddTable = false;  
        //  
        //  
        //this.http.get(this.bseUrl + 'api/InventoryMasterAPI/Inventory').subscribe(result => {  
        //    this.Inventory = result.json();  
        //}, error => console.error(error));   
    }
    addInventoryDetails(item  : InventoryMaster){
        if(item.inventoryID ==0){ // call add stock
            this._stockService.addStock(item)
            .subscribe((data) => {  
                this.getData(); 
            }) 
        }
        else {  // call update stock
            this._stockService.updateStock(item)
            .subscribe((data) =>{
                // to get updated data
                this.getData();
            })

        }
        this.AddTable = false; 
    }

     //to Delete the selected Inventory detail from database.  
     deleteinventoryDetails(inventoryIDs: number) {  
        var ans = confirm("Do you want to delete customer with Id: " + inventoryIDs);  
        if (ans) {  
            this._stockService.deleteStock(inventoryIDs).subscribe((data) => {  
                this.getData();  
            }, error => console.error(error))   
        } 
    }  
  
    closeEdits() {  
        this.AddTable = false;  
        this.item = {
            inventoryID : 0,
            itemName: "",
            stockQty: 0,
            departmentId:0,
            departmentName:"",
            inQuantity:0,
            outQuantity:0,
            priorityStatus:0,
            reorderQty:0
        } 
    } 

}

export interface InventoryMaster {  
    inventoryID: number;  
    itemName: string;  
    stockQty: number; 
    inQuantity: number;
    outQuantity: number; 
    reorderQty: number;  
    priorityStatus: number;
    departmentId: number;
    departmentName: string; 
} 
export interface Department{
Id : number;
departmentName: string;
}
