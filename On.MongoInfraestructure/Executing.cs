using Domain.DTO;
using Domain.Enums;
using Domain_Application.DTO.SqlDTO;
using Microsoft.Extensions.Configuration;
using On.MongoMigrations.DAL;
using On.MongoMigrations.DAL.Util;
using System.Collections.Generic;
using System.Linq;
using UserDAL.Repositories;

namespace On.MongoMigrations
{
    public class Executing
    {

        public static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
        {

            ServicesConfiguration.ReadJson();
            ServicesConfiguration.MongoConfiguration();
            ServicesConfiguration.SqlServerConfiguration();
            IList<DiarySettingsPeriodDTO> diary = new List<DiarySettingsPeriodDTO>();
            DiarySettingsPeriodDTO document;


            var mongoSettings = new SettingsRepository();
            var Sqlclasses = new ClassRepository();

            // Find All Documents in this Collection ....
            var mongoFindAll = mongoSettings.FindAll();
            //var mongoFindAll = mongoSettings.FindAllTeste();
            
            foreach (var findAll in mongoFindAll)
            {
                int school = findAll.School;

                IList<ClassDTO> GetClassByIdSchool = Sqlclasses.GetClassByIdSchool(school);

                var CountMorning = GetClassByIdSchool.Count(x => x.ShiftTypeId == 1);
                var CountEvening = GetClassByIdSchool.Count(x => x.ShiftTypeId == 2);
                var CountIntegral = GetClassByIdSchool.Count(x => x.ShiftTypeId == 4);

                document = new DiarySettingsPeriodDTO();

                document.School = findAll.School;
                document.IsGuarianAllowedToSendMessage = findAll.IsGuarianAllowedToSendMessage;

                    if (CountMorning > 0)
                    {
                        ExistMorning(document, findAll);
                    } else
                    {
                        DoesNotExistMorning(document, findAll);
                    }

                    if (CountEvening > 0)
                    {
                        ExistEvening(document, findAll);
                    } else
                    {
                        DoesNotExistEvening(document, findAll);
                    }

                    if (CountIntegral > 0)
                    {
                        ExistIntegral(document, findAll);
                    } else
                    {
                        DoesNotExistIntegral(document, findAll);
                    }

                    diary.Add(document);
                    var deletedFilter = mongoFindAll.Select(d => d.School);
                    mongoSettings.DeletedAll(deletedFilter);
                    //mongoSettings.DeletedAllTeste(deletedFilter);
            }

             //var trying = mongoSettings.FindAllTeste();
            var trying = mongoSettings.FindAll();

            foreach (var list in diary)
            {
                mongoSettings.InsertOne(list);
            }
        }

        private static void ExistIntegral(DiarySettingsPeriodDTO document, DiarySettingsDTO findAll)
        {
            foreach (var teste in findAll.MealSetting.Items)
            {
                if (teste.Key.Equals(EMealType.Lunch))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.lunchIntegral, teste.Value);
                }

                if (teste.Key.Equals(EMealType.Dinner))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.dinnerIntegral, teste.Value);

                }
                if (teste.Key.Equals(EMealType.Snack))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.snackIntegral, teste.Value);
                }

                if (teste.Key.Equals(EMealType.Brunch))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.brunchIntegral, teste.Value);
                }

            }

            foreach (var teste in findAll.NapSetting.Items)
            {
                if (teste.Key.Equals(EPeriod.Morning))
                {
                    document.NapSettingPeriods.Items.Add(EPeriodSettings.morningIntegral, teste.Value);
                }

                if (teste.Key.Equals(EPeriod.Afternoon))
                {
                    document.NapSettingPeriods.Items.Add(EPeriodSettings.afternoonIntegral, teste.Value);
                }
            }


            document.MyDayPeriods.Items.Add(EMyDaySettings.MyDayInfoIntegral, findAll.ShowMyDayInfo);
            document.MyPopInfos.Items.Add(EMyPopSettings.ShowPopInfoIntegral, findAll.ShowPoopInfo);
        }

        private static void ExistEvening(DiarySettingsPeriodDTO document, DiarySettingsDTO findAll)
        {
            foreach (var teste in findAll.MealSetting.Items)
            {
                if (teste.Key.Equals(EMealType.Lunch))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.lunchEvening, teste.Value);
                }

                if (teste.Key.Equals(EMealType.Dinner))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.dinnerEvening, teste.Value);
                }

                if (teste.Key.Equals(EMealType.Snack))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.snackEvening, teste.Value);
                }

            }

            foreach (var teste in findAll.NapSetting.Items)
            {

                if (teste.Key.Equals(EPeriod.Afternoon))
                {
                    document.NapSettingPeriods.Items.Add(EPeriodSettings.afternoon, teste.Value);
                }
            }

            document.MyDayPeriods.Items.Add(EMyDaySettings.MyDayInfoEvening, findAll.ShowMyDayInfo);
            document.MyPopInfos.Items.Add(EMyPopSettings.ShowPopInfoEvening, findAll.ShowPoopInfo);
        }

        private static void ExistMorning(DiarySettingsPeriodDTO document, DiarySettingsDTO findAll)
        {
            foreach (var teste in findAll.MealSetting.Items)
            {

                if (teste.Key.Equals(EMealType.Lunch))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.lunchMorning, teste.Value);
                }

                if (teste.Key.Equals(EMealType.Brunch))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.brunchMorning, teste.Value);
                }
            }

            foreach (var teste in findAll.NapSetting.Items)
            {
                if (teste.Key.Equals(EPeriod.Morning))
                {
                    document.NapSettingPeriods.Items.Add(EPeriodSettings.morning, teste.Value);
                }

            }

            document.MyDayPeriods.Items.Add(EMyDaySettings.MyDayInfoMorning, findAll.ShowMyDayInfo);
            document.MyPopInfos.Items.Add(EMyPopSettings.ShowPopInfoMorning, findAll.ShowPoopInfo);
        }

        private static void DoesNotExistMorning(DiarySettingsPeriodDTO document, DiarySettingsDTO findAll)
        {
            foreach (var teste in findAll.MealSetting.Items)
            {

                if (teste.Key.Equals(EMealType.Lunch))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.lunchMorning, false);
                }

                if (teste.Key.Equals(EMealType.Brunch))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.brunchMorning, false);
                }
            }

            foreach (var teste in findAll.NapSetting.Items)
            {
                if (teste.Key.Equals(EPeriod.Morning))
                {
                    document.NapSettingPeriods.Items.Add(EPeriodSettings.morning, false);
                }

            }

            document.MyDayPeriods.Items.Add(EMyDaySettings.MyDayInfoMorning, false);
            document.MyPopInfos.Items.Add(EMyPopSettings.ShowPopInfoMorning, false);
        }

        private static void DoesNotExistEvening(DiarySettingsPeriodDTO document, DiarySettingsDTO findAll)
        {
            foreach (var teste in findAll.MealSetting.Items)
            {
                if (teste.Key.Equals(EMealType.Lunch))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.lunchEvening, false);
                }

                if (teste.Key.Equals(EMealType.Dinner))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.dinnerEvening, false);
                }

                if (teste.Key.Equals(EMealType.Snack))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.snackEvening, false);
                }

            }

            foreach (var teste in findAll.NapSetting.Items)
            {

                if (teste.Key.Equals(EPeriod.Afternoon))
                {
                    document.NapSettingPeriods.Items.Add(EPeriodSettings.afternoon, false);
                }
            }

            document.MyDayPeriods.Items.Add(EMyDaySettings.MyDayInfoEvening, false);
            document.MyPopInfos.Items.Add(EMyPopSettings.ShowPopInfoEvening, false);
        }

        private static void DoesNotExistIntegral(DiarySettingsPeriodDTO document, DiarySettingsDTO findAll)
        {
            foreach (var teste in findAll.MealSetting.Items)
            {
                if (teste.Key.Equals(EMealType.Lunch))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.lunchIntegral, false);
                }

                if (teste.Key.Equals(EMealType.Dinner))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.dinnerIntegral, false);

                }
                if (teste.Key.Equals(EMealType.Snack))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.snackIntegral, false);
                }

                if (teste.Key.Equals(EMealType.Brunch))
                {
                    document.MealSettingPeriods.Items.Add(EMealTypePeriodSettings.brunchIntegral, false);
                }

            }

            foreach (var teste in findAll.NapSetting.Items)
            {
                if (teste.Key.Equals(EPeriod.Morning))
                {
                    document.NapSettingPeriods.Items.Add(EPeriodSettings.morningIntegral, false);
                }

                if (teste.Key.Equals(EPeriod.Afternoon))
                {
                    document.NapSettingPeriods.Items.Add(EPeriodSettings.afternoonIntegral, false);
                }
            }


            document.MyDayPeriods.Items.Add(EMyDaySettings.MyDayInfoIntegral, false);
            document.MyPopInfos.Items.Add(EMyPopSettings.ShowPopInfoIntegral, false);
        }
    }
}