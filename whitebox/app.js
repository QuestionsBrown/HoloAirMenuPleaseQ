"use strict";
const $ = id => document.getElementById(id);
let catalog, selected, angle = 0.5, dark = false, previewUrls = [], validPhotos = [];
const ctx = $("mesh").getContext("2d");
function draw() {
  const canvas = $("mesh"), rect = canvas.getBoundingClientRect(), ratio = window.devicePixelRatio || 1;
  canvas.width = Math.round(rect.width * ratio); canvas.height = Math.round(rect.height * ratio);
  ctx.setTransform(ratio,0,0,ratio,0,0); ctx.clearRect(0,0,rect.width,rect.height);
  const scale = Math.min(rect.width,rect.height)*0.24;
  const points = [[-1,-0.6,-1],[1,-0.6,-1],[1,0.6,-1],[-1,0.6,-1],[-1,-0.6,1],[1,-0.6,1],[1,0.6,1],[-1,0.6,1]].map(([x,y,z])=>{
    const rx=x*Math.cos(angle)-z*Math.sin(angle), rz=x*Math.sin(angle)+z*Math.cos(angle);
    return [rect.width/2+rx*scale,rect.height/2+(y+rz*0.27)*scale];
  });
  ctx.strokeStyle=dark?"#b4ddbc":"#37644a";ctx.lineWidth=2;
  for (const [a,b] of [[0,1],[1,2],[2,3],[3,0],[4,5],[5,6],[6,7],[7,4],[0,4],[1,5],[2,6],[3,7]]) {
    ctx.beginPath();ctx.moveTo(...points[a]);ctx.lineTo(...points[b]);ctx.stroke();
  }
}
function money(minor) { return new Intl.NumberFormat(undefined,{style:"currency",currency:catalog.restaurant.currency}).format(minor/100); }
function choose(item) { selected=item; $("item-title").textContent=item.name;$("description").textContent=item.description;$("price").textContent=money(item.priceMinor);angle=0.5;draw(); }
function renderItems() {
  $("items").replaceChildren();
  const items=catalog.items.filter(i=>i.available&&($("category").value==="all"||i.category===$("category").value));
  for(const item of items){const button=document.createElement("button");button.className="item";button.textContent=item.name+" · "+money(item.priceMinor);button.onclick=()=>choose(item);$("items").append(button);}
  if(items.length)choose(items[0]);
}
document.querySelectorAll("[data-tab]").forEach(button=>button.onclick=()=>{
  document.querySelectorAll("[data-tab]").forEach(b=>b.setAttribute("aria-pressed",String(b===button)));
  for(const id of ["menu","studio","system"])$(id).hidden=id!==button.dataset.tab;
  if(button.dataset.tab==="menu")draw();
});
$("mode").onclick=()=>{dark=!dark;$("viewer").classList.toggle("dark",dark);$("mode").setAttribute("aria-pressed",String(dark));draw();};
$("reset").onclick=()=>{angle=0.5;draw();};
$("rotate-left").onclick=()=>{angle-=0.3;draw();};$("rotate-right").onclick=()=>{angle+=0.3;draw();};
let drag=null;
$("mesh").onpointerdown=e=>{drag=e.clientX;$("mesh").setPointerCapture(e.pointerId);};
$("mesh").onpointermove=e=>{if(drag===null)return;angle+=(e.clientX-drag)*0.012;drag=e.clientX;draw();};
$("mesh").onpointerup=$("mesh").onpointercancel=$("mesh").onlostpointercapture=()=>{drag=null;};
window.addEventListener("resize",draw);
$("photos").onchange=()=>{
  previewUrls.forEach(URL.revokeObjectURL);previewUrls=[];validPhotos=[];$("previews").replaceChildren();$("request").textContent="";$("draft").disabled=true;
  const files=Array.from($("photos").files);
  if(files.length>12||files.some(f=>!["image/jpeg","image/png","image/webp"].includes(f.type)||f.size>10*1024*1024)){ $("photo-status").textContent="Choose up to 12 JPEG, PNG or WebP photos, each at most 10 MB.";return;}
  validPhotos=files;
  for(const file of files){const url=URL.createObjectURL(file);previewUrls.push(url);const img=document.createElement("img");img.src=url;img.alt=file.name;img.width=90;img.height=90;img.style.objectFit="cover";$("previews").append(img);}
  $("photo-status").textContent=files.length+" photo(s) selected locally.";$("draft").disabled=!files.length;
};
$("draft").onclick=()=>{$("request").textContent="Local preview: "+validPhotos.length+" photo(s) for "+$("target").selectedOptions[0].textContent+". Nothing submitted; reconstruction service not connected.";};
async function start(){
 try{
  const response=await fetch("./data/menu.json");if(!response.ok)throw new Error("Menu request failed");
  catalog=await response.json();if(!catalog.restaurant||!Array.isArray(catalog.items)||!catalog.items.length)throw new Error("Invalid menu");
  $("restaurant").textContent=catalog.restaurant.name;
  for(const [value,label] of [["all","All dishes"],...Array.from(new Set(catalog.items.map(i=>i.category))).map(c=>[c,c])])$("category").add(new Option(label,value));
  for(const item of catalog.items)$("target").add(new Option(item.name,item.id));
  $("category").onchange=renderItems;renderItems();
  const url=catalog.restaurant.orderingUrl;
  if(url){const parsed=new URL(url);if(parsed.protocol!=="https:")throw new Error("Ordering URL must use HTTPS");$("order").href=parsed.href;$("order").hidden=false;$("order-unavailable").hidden=true;}
  $("status").textContent="Sample menu ready. Changes in this demo are not saved.";
 }catch(error){$("status").textContent="Could not load menu. Serve this folder over HTTP and check data/menu.json.";console.error(error);}
}
start();
