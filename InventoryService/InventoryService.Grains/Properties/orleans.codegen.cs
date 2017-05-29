#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 414
#pragma warning disable 649
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998
[assembly: global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.1.0")]
[assembly: global::Orleans.CodeGeneration.OrleansCodeGenerationTargetAttribute("InventoryService.Grains, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
namespace InventoryService.Grains
{
    using global::Orleans.Async;
    using global::Orleans;
    using global::System.Reflection;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.1.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::InventoryService.Grains.IInventoryServiceGrain))]
    internal class OrleansCodeGenInventoryServiceGrainReference : global::Orleans.Runtime.GrainReference, global::InventoryService.Grains.IInventoryServiceGrain
    {
        protected @OrleansCodeGenInventoryServiceGrainReference(global::Orleans.Runtime.GrainReference @other): base (@other)
        {
        }

        protected @OrleansCodeGenInventoryServiceGrainReference(global::System.Runtime.Serialization.SerializationInfo @info, global::System.Runtime.Serialization.StreamingContext @context): base (@info, @context)
        {
        }

        protected override global::System.Int32 InterfaceId
        {
            get
            {
                return 460239684;
            }
        }

        public override global::System.String InterfaceName
        {
            get
            {
                return "global::InventoryService.Grains.IInventoryServiceGrain";
            }
        }

        public override global::System.Boolean @IsCompatible(global::System.Int32 @interfaceId)
        {
            return @interfaceId == 460239684;
        }

        protected override global::System.String @GetMethodName(global::System.Int32 @interfaceId, global::System.Int32 @methodId)
        {
            switch (@interfaceId)
            {
                case 460239684:
                    switch (@methodId)
                    {
                        case 1737518932:
                            return "ShipItems";
                        case 1126600635:
                            return "RestockItems";
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + 460239684 + ",methodId=" + @methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
            }
        }

        public global::System.Threading.Tasks.Task @ShipItems(global::InventoryService.Interface.Product @product, global::System.Int32 @quantity)
        {
            return base.@InvokeMethodAsync<global::System.Object>(1737518932, new global::System.Object[]{@product, @quantity});
        }

        public global::System.Threading.Tasks.Task @RestockItems(global::InventoryService.Interface.Product @product, global::System.Int32 @quantity)
        {
            return base.@InvokeMethodAsync<global::System.Object>(1126600635, new global::System.Object[]{@product, @quantity});
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.1.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute("global::InventoryService.Grains.IInventoryServiceGrain", 460239684, typeof (global::InventoryService.Grains.IInventoryServiceGrain)), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    internal class OrleansCodeGenInventoryServiceGrainMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        public global::System.Threading.Tasks.Task<global::System.Object> @Invoke(global::Orleans.Runtime.IAddressable @grain, global::Orleans.CodeGeneration.InvokeMethodRequest @request)
        {
            global::System.Int32 interfaceId = @request.@InterfaceId;
            global::System.Int32 methodId = @request.@MethodId;
            global::System.Object[] arguments = @request.@Arguments;
            if (@grain == null)
                throw new global::System.ArgumentNullException("grain");
            switch (interfaceId)
            {
                case 460239684:
                    switch (methodId)
                    {
                        case 1737518932:
                            return ((global::InventoryService.Grains.IInventoryServiceGrain)@grain).@ShipItems((global::InventoryService.Interface.Product)arguments[0], (global::System.Int32)arguments[1]).@Box();
                        case 1126600635:
                            return ((global::InventoryService.Grains.IInventoryServiceGrain)@grain).@RestockItems((global::InventoryService.Interface.Product)arguments[0], (global::System.Int32)arguments[1]).@Box();
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + 460239684 + ",methodId=" + methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + interfaceId);
            }
        }

        public global::System.Int32 InterfaceId
        {
            get
            {
                return 460239684;
            }
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.1.0"), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.SerializerAttribute(typeof (global::InventoryService.Interface.Product)), global::Orleans.CodeGeneration.RegisterSerializerAttribute]
    internal class OrleansCodeGenInventoryService_Interface_ProductSerializer
    {
        [global::Orleans.CodeGeneration.CopierMethodAttribute]
        public static global::System.Object DeepCopier(global::System.Object original)
        {
            global::InventoryService.Interface.Product input = ((global::InventoryService.Interface.Product)original);
            global::InventoryService.Interface.Product result = new global::InventoryService.Interface.Product();
            global::Orleans.@Serialization.@SerializationContext.@Current.@RecordObject(original, result);
            result.@Id = (global::System.Guid)global::Orleans.Serialization.SerializationManager.@DeepCopyInner(input.@Id);
            result.@Name = input.@Name;
            return result;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::InventoryService.Interface.Product input = (global::InventoryService.Interface.Product)untypedInput;
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Id, stream, typeof (global::System.Guid));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Name, stream, typeof (global::System.String));
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::InventoryService.Interface.Product result = new global::InventoryService.Interface.Product();
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
            result.@Id = (global::System.Guid)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Guid), stream);
            result.@Name = (global::System.String)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.String), stream);
            return (global::InventoryService.Interface.Product)result;
        }

        public static void Register()
        {
            global::Orleans.Serialization.SerializationManager.@Register(typeof (global::InventoryService.Interface.Product), DeepCopier, Serializer, Deserializer);
        }

        static OrleansCodeGenInventoryService_Interface_ProductSerializer()
        {
            Register();
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.1.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::InventoryService.Grains.IProductGrain))]
    internal class OrleansCodeGenProductGrainReference : global::Orleans.Runtime.GrainReference, global::InventoryService.Grains.IProductGrain
    {
        protected @OrleansCodeGenProductGrainReference(global::Orleans.Runtime.GrainReference @other): base (@other)
        {
        }

        protected @OrleansCodeGenProductGrainReference(global::System.Runtime.Serialization.SerializationInfo @info, global::System.Runtime.Serialization.StreamingContext @context): base (@info, @context)
        {
        }

        protected override global::System.Int32 InterfaceId
        {
            get
            {
                return 2107013953;
            }
        }

        public override global::System.String InterfaceName
        {
            get
            {
                return "global::InventoryService.Grains.IProductGrain";
            }
        }

        public override global::System.Boolean @IsCompatible(global::System.Int32 @interfaceId)
        {
            return @interfaceId == 2107013953;
        }

        protected override global::System.String @GetMethodName(global::System.Int32 @interfaceId, global::System.Int32 @methodId)
        {
            switch (@interfaceId)
            {
                case 2107013953:
                    switch (@methodId)
                    {
                        case -1077269448:
                            return "GetCurrentStock";
                        case 1827468844:
                            return "ModifyStock";
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + 2107013953 + ",methodId=" + @methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
            }
        }

        public global::System.Threading.Tasks.Task<global::System.Int32> @GetCurrentStock()
        {
            return base.@InvokeMethodAsync<global::System.Int32>(-1077269448, null);
        }

        public global::System.Threading.Tasks.Task @ModifyStock(global::System.Int32 @quantity)
        {
            return base.@InvokeMethodAsync<global::System.Object>(1827468844, new global::System.Object[]{@quantity});
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.3.1.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute("global::InventoryService.Grains.IProductGrain", 2107013953, typeof (global::InventoryService.Grains.IProductGrain)), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    internal class OrleansCodeGenProductGrainMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        public global::System.Threading.Tasks.Task<global::System.Object> @Invoke(global::Orleans.Runtime.IAddressable @grain, global::Orleans.CodeGeneration.InvokeMethodRequest @request)
        {
            global::System.Int32 interfaceId = @request.@InterfaceId;
            global::System.Int32 methodId = @request.@MethodId;
            global::System.Object[] arguments = @request.@Arguments;
            if (@grain == null)
                throw new global::System.ArgumentNullException("grain");
            switch (interfaceId)
            {
                case 2107013953:
                    switch (methodId)
                    {
                        case -1077269448:
                            return ((global::InventoryService.Grains.IProductGrain)@grain).@GetCurrentStock().@Box();
                        case 1827468844:
                            return ((global::InventoryService.Grains.IProductGrain)@grain).@ModifyStock((global::System.Int32)arguments[0]).@Box();
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + 2107013953 + ",methodId=" + methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + interfaceId);
            }
        }

        public global::System.Int32 InterfaceId
        {
            get
            {
                return 2107013953;
            }
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 649
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif
